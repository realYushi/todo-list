// frontend/src/pages/Task/TaskListInput.tsx
import IList from "@models/ListInterface"
import { useAddListMutation, useUpdateListMutation } from "@service/listEndpoint"
import { useState, useEffect } from "react"

interface TaskListInputProps {
  onListClose: () => void
  listToUpdate: IList | null
}

/**
 * Component for rendering a form to add or update a list.
 */
export default function TaskListInput({
  onListClose,
  listToUpdate,
}: TaskListInputProps) {
  const [addList] = useAddListMutation()
  const [updateList] = useUpdateListMutation()
  // State variables for storing the input values
  const [title, setTitle] = useState<string>("")
  const [description, setDescription] = useState<string>("")

  // Set the input values when the listToUpdate prop changes
  useEffect(() => {
    if (listToUpdate) {
      setTitle(listToUpdate.title)
      setDescription(listToUpdate.description)
    }
  }, [listToUpdate])

  /**
   * Handles the list submission.
   * If listToUpdate is provided, updates the list, otherwise adds a new list.
   * Dispatches the appropriate action and closes the form.
   */
  const handleList = () => {
    const list: IList = {
      listId: listToUpdate ? listToUpdate.listId : Date.now().toString(),
      title,
      description,
      tasks: listToUpdate ? listToUpdate.tasks : [],
    }

    if (listToUpdate) {
      updateList(list)
    } else {
      addList(list)
    }
    onListClose()
  }

  return (
    <div className="absolute rounded-lg bg-neutral-50 p-4">
      <div className="label">
        <span className="label-text">List Name</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        value={title}
        onChange={e => setTitle(e.target.value)}
        className="input input-bordered input-secondary w-full"
      />
      <div className="label">
        <span className="label-text">List Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea
        value={description}
        onChange={e => setDescription(e.target.value)}
        className="textarea textarea-bordered w-full"
      ></textarea>
      <div className="mt-5">
        <button className="btn btn-primary w-1/2" onClick={handleList}>
          Confirm
        </button>
        <button className="btn btn-warning w-1/2" onClick={onListClose}>
          Cancel
        </button>
      </div>
    </div>
  )
}
