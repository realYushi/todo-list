import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import {
  faTrash,
  faPen,
  faCheckCircle,
  faHourglassHalf,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons"
import ITask from "@models/TaskInterface"
import { useEffect, useState } from "react"
import {
  useDeleteTaskMutation,
  useUpdateTaskMutation,
} from "@service/taskEndpoint"

interface TaskProps {
  task: ITask
  onUpdateTaskClick: (task: ITask) => void
}

/**
 * Component representing a single task item.
 * @param {TaskProps} props - The props for the TaskItem component.
 * @param {ITask} props.task - The task object.
 * @param {(task: ITask) => void} props.onUpdateTaskClick - The function to call when the task is updated.
 * @returns {JSX.Element} The TaskItem component.
 */
export default function TaskItem({
  task,
  onUpdateTaskClick,
}: TaskProps): JSX.Element {
  const [deleteTask] = useDeleteTaskMutation()
  const [updateTask] = useUpdateTaskMutation()
  const handleDeleteTask = () => {
    deleteTask(task.taskId)
  }
  const [taskStatus, setTaskStatus] = useState(faHourglassHalf)
  useEffect(() => {
    switch (task.status) {
      case "Completed":
        setTaskStatus(faCheckCircle)
        break
      case "InProgress":
        setTaskStatus(faHourglassHalf)
        break
    }
    if (
      new Date(task.dueDate) <=
        new Date(new Date().setDate(new Date().getDate() - 1)) &&
      task.status !== "Completed"
    ) {
      setTaskStatus(faExclamationTriangle)
    }
  })

  const handelCompleteTask = () => {
    updateTask({
      ...task,
      status: task.status === "Completed" ? "InProgress" : "Completed",
    })
  }

  return (
    <div className={`${task.status === "Completed" ? "line-through" : ""} `}>
      <label className="label relative m-4 flex items-center rounded-md p-4 shadow-md">
        <input
          checked={task.status === "Completed"}
          type="checkbox"
          className="checkbox checkbox-md mr-4 size-8"
          onClick={handelCompleteTask}
        />
        <div className="flex-grow">
          <div className="flex gap-4">
            <FontAwesomeIcon className="mt-1" icon={taskStatus} />
            <h3 className="text-xl">{task.title}</h3>
          </div>
          <p className="text-sm">{task.description}</p>
          <p className="text-sm">{task.dueDate.toString()}</p>
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
