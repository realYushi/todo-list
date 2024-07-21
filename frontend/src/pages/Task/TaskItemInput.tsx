import ITask from "@models/TaskInterface"
import { useAddTaskMutation, useUpdateTaskMutation } from "@servicetaskEndpoint"
import { useState, useEffect } from "react"

interface TaskItemInputProps {
  onTaskClose: () => void
  listId: string
  taskToUpdate: ITask | null
}

/**
 * Component for rendering a form to add or update a task.
 */
export default function TaskItemInput({
  onTaskClose,
  taskToUpdate,
  listId,
}: TaskItemInputProps) {
  const [updateTask] = useUpdateTaskMutation()
  const [addTask] = useAddTaskMutation()
  // State variables for storing the input values
  const [title, setTitle] = useState<string>("")
  const [description, setDescription] = useState<string>("")
  const [dueDate, setDueDate] = useState<string>("")

  // Set the input values when the taskToUpdate prop changes
  useEffect(() => {
    if (taskToUpdate) {
      setTitle(taskToUpdate.title)
      setDescription(taskToUpdate.description)
      setDueDate(taskToUpdate.dueDate)
    }
  }, [taskToUpdate])

  /**
   * Handles the task submission.
   * If taskToUpdate is provided, updates the task, otherwise adds a new task.
   * Dispatches the appropriate action and closes the form.
   */
  const handleTask = () => {
    const task: ITask = {
      taskId: taskToUpdate ? taskToUpdate.taskId : Date.now().toString(),
      title,
      description,
      dueDate,
      listId: taskToUpdate ? taskToUpdate.listId : listId,
      status: taskToUpdate ? taskToUpdate.status : "InProgress",
    }

    if (taskToUpdate) {
      updateTask(task)
    } else {
      addTask(task)
    }
    onTaskClose()
  }

  return (
    <div className="absolute rounded-lg bg-neutral-50 p-4">
      <div className="label">
        <span className="label-text">Task Name</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        value={title}
        onChange={e => setTitle(e.target.value)}
        className="input input-bordered input-secondary w-full"
      />
      <div className="label">
        <span className="label-text">Task Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea
        value={description}
        onChange={e => setDescription(e.target.value)}
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
          onChange={e => setDueDate(e.target.value.toString())}
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
