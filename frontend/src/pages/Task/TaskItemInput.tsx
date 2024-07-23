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

/**
 * Component for creating or updating a task.
 */
export default function TaskItemInput({
  onTaskClose,
  taskToUpdate,
  listId,
}: TaskItemInputProps) {
  const [updateTask] = useUpdateTaskMutation()
  const [addTask] = useAddTaskMutation()

  const [title, setTitle] = useState<string>("")
  const [description, setDescription] = useState<string>("")
  const [dueDate, setDueDate] = useState<string>("")

  useEffect(() => {
    if (taskToUpdate) {
      setTitle(taskToUpdate.title)
      setDescription(taskToUpdate.description || "")
      setDueDate(taskToUpdate.dueDate || "")
    }
  }, [taskToUpdate])

  /**
   * Handles the task creation or update.
   */
  const handleTask = () => {
    const formattedDueDate = dueDate ? dueDate : undefined

    const baseTask = {
      title,
      description,
      listId: taskToUpdate ? taskToUpdate.listId : listId,
      dueDate: formattedDueDate,
    }

    const task: Partial<ITask> = taskToUpdate
      ? {
          ...baseTask,
          taskId: taskToUpdate.taskId,
          status: taskToUpdate.status,
        }
      : { ...baseTask, status: StatusEnum.Pending }

    if (taskToUpdate) {
      updateTask(task)
    } else {
      addTask(task)
    }
    onTaskClose()
  }

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
            const inputDate = e.target.value
            setDueDate(inputDate) // Set the date directly without formatting
          }}
          className="input input-bordered w-full"
        />
        {dueDate && (
          <button
            className="btn btn-ghost btn-sm ml-2"
            onClick={() => setDueDate("")}
          >
            Clear
          </button>
        )}
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
