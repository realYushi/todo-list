import ITask from "@models/TaskInterface"
import {
  useAddTaskMutation,
  useUpdateTaskMutation,
} from "@service/taskEndpoint"
import { useState, useEffect } from "react"

interface TaskItemInputProps {
  onTaskClose: () => void
  listId: string
  taskToUpdate: ITask | null
}

enum StatusEnum {
  Pending = 1,
  InProgress = 2,
  Completed = 3,
}

export default function TaskItemInput({
  onTaskClose,
  taskToUpdate,
  listId,
}: TaskItemInputProps) {
  console.log("TaskItemInput component rendered", { taskToUpdate, listId })

  const [updateTask] = useUpdateTaskMutation()
  const [addTask] = useAddTaskMutation()

  const [title, setTitle] = useState<string>("")
  const [description, setDescription] = useState<string>("")
  const [dueDate, setDueDate] = useState<string>("")

  useEffect(() => {
    console.log("useEffect triggered", { taskToUpdate })
    if (taskToUpdate) {
      setTitle(taskToUpdate.title)
      setDescription(taskToUpdate.description || "")
      setDueDate(taskToUpdate.dueDate || "")
      console.log("Task data set from taskToUpdate", {
        title,
        description,
        dueDate,
      })
    }
  }, [taskToUpdate])

  const handleTask = () => {
    console.log("handleTask called")
    const formattedDueDate = dueDate
      ? new Date(dueDate).toISOString()
      : undefined

    console.log("Formatted due date", formattedDueDate)

    const baseTask = {
      title,
      description,
      listId: taskToUpdate ? taskToUpdate.listId : listId,
      dueDate: formattedDueDate,
    }

    console.log("Base task created", baseTask)

    const task: Partial<ITask> = taskToUpdate
      ? {
          ...baseTask,
          taskId: taskToUpdate.taskId,
          status: taskToUpdate.status,
        }
      : { ...baseTask, status: StatusEnum.Pending }

    console.log("Final task object", task)

    if (taskToUpdate) {
      console.log("Updating existing task")
      updateTask(task)
    } else {
      console.log("Adding new task")
      addTask(task)
    }
    onTaskClose()
  }

  console.log("Current state", { title, description, dueDate })

  return (
    <div className="absolute rounded-lg backdrop-blur-xl p-4">
      <div className="label">
        <span className="label-text">Task Name</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        value={title}
        onChange={e => {
          setTitle(e.target.value)
          console.log("Title changed", e.target.value)
        }}
        className="input input-bordered input-secondary w-full"
      />
      <div className="label">
        <span className="label-text">Task Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea
        value={description}
        onChange={e => {
          setDescription(e.target.value)
          console.log("Description changed", e.target.value)
        }}
        className="textarea textarea-bordered w-full"
      ></textarea>
      <div className="label">
        <span className="label-text">Due Date</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <div className="flex items-center">
        <input
          type="date"
          value={dueDate}
          onChange={e => {
            setDueDate(e.target.value.toString())
            console.log("Due date changed", e.target.value)
          }}
          className="input input-bordered w-full"
        />
      </div>
      <div className="mt-5">
        <button className="btn btn-primary w-1/2" onClick={handleTask}>
          Confirm
        </button>
        <button className="btn btn-warning w-1/2" onClick={onTaskClose}>
          Close
        </button>
      </div>
    </div>
  )
}
