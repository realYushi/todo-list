import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import {
  faTrash,
  faPen,
  faCheckCircle,
  faHourglassHalf,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons"
import { useEffect, useState } from "react"
import {
  useDeleteTaskMutation,
  useUpdateTaskMutation,
} from "@service/taskEndpoint"
import ITask from "@models/TaskInterface"

export enum StatusEnum {
  Pending = 1,
  InProgress = 2,
  Completed = 3,
}

interface TaskProps {
  task: ITask
  onUpdateTaskClick: (task: ITask) => void
}

export default function TaskItem({
  task,
  onUpdateTaskClick,
}: TaskProps): JSX.Element {
  const [deleteTask] = useDeleteTaskMutation()
  const [updateTask] = useUpdateTaskMutation()
  const [taskStatus, setTaskStatus] = useState(faHourglassHalf)

  useEffect(() => {
    switch (task.status) {
      case StatusEnum.Completed:
        setTaskStatus(faCheckCircle)
        break
      case StatusEnum.InProgress:
        setTaskStatus(faHourglassHalf)
        break
      case StatusEnum.Pending:
        setTaskStatus(faHourglassHalf)
        break
    }
    if (
      new Date(task.dueDate) <=
        new Date(new Date().setDate(new Date().getDate() - 1)) &&
      task.status !== StatusEnum.Completed
    ) {
      setTaskStatus(faExclamationTriangle)
    }
  }, [task.status, task.dueDate])

  const handleDeleteTask = () => {
    deleteTask(task.taskId)
  }

  const handleCompleteTask = () => {
    const newStatus =
      task.status === StatusEnum.Completed
        ? StatusEnum.InProgress
        : StatusEnum.Completed

    updateTask({
      ...task,
      status: newStatus,
    })
  }

  return (
    <div
      className={`${task.status === StatusEnum.Completed ? "line-through" : ""} `}
    >
      <label className="label relative m-4 flex items-center rounded-md p-4 shadow-md">
        <input
          checked={task.status === StatusEnum.Completed}
          type="checkbox"
          className="checkbox checkbox-md mr-4 size-8"
          onClick={handleCompleteTask}
        />
        <div className="flex-grow">
          <div className="flex gap-4">
            <FontAwesomeIcon className="mt-1" icon={taskStatus} />
            <h3 className="text-xl">{task.title}</h3>
          </div>
          <p className="text-sm">{task.description}</p>
          <p className="text-sm">{task.dueDate}</p>
        </div>
        <div className="flex flex-col space-y-2">
          <button className="btn btn-circle btn-sm" onClick={handleDeleteTask}>
            <FontAwesomeIcon className="size-4" icon={faTrash} />
          </button>
          <button
            className="btn btn-circle btn-sm"
            onClick={() => onUpdateTaskClick(task)}
          >
            <FontAwesomeIcon className="size-4" icon={faPen} />
          </button>
        </div>
      </label>
    </div>
  )
}
