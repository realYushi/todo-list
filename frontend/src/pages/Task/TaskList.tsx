import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faTrash, faPen } from "@fortawesome/free-solid-svg-icons"
import TaskItems from "./TaskItems"
import ITask from "@models/TaskInterface"
import IList from "@models/ListInterface"
import { useAddTaskMutation, useGetTasksQuery } from "@servicetaskEndpoint"
import { useDeleteListMutation, useGetListsQuery } from "@servicelistEndpoint"

interface TaskListProps {
  list: IList
  onUpdateListClick: (list: IList) => void
  onUpdateTaskClick: (task: ITask) => void
  onAddTaskClick: (listId: string) => void
}

/**
 * Component that renders a list of tasks.
 * @param list - The list object containing the tasks.
 * @param onAddTaskClick - Callback function to handle adding a new task.
 */
export default function TaskList({
  list,
  onAddTaskClick,
  onUpdateTaskClick,
  onUpdateListClick,
}: TaskListProps) {
  // Get the tasks from the Redux store that belong to the current list
  const [deleteList] = useDeleteListMutation()
  const { data: tasks = [], isLoading, isError } = useGetTasksQuery()
  const { data: lists } = useGetListsQuery() // Add this line to fetch all lists

  const filteredTasks: ITask[] = tasks.filter(
    task => task.listId === list.listId,
  )

  /**
   * Handles the click event when the "Add Task" button is clicked.
   */
  const handleAddClicked = () => {
    onAddTaskClick(list.listId ?? "")
  }
  const handleUpdateListClicked = () => {
    onUpdateListClick(list)
  }
  const handelDeleteListClicked = () => {
    if (lists && lists.length > 1) {
      deleteList(list.listId ?? "")
    } else {
      // Show an error message or notification
      alert("Cannot delete the last list")
      // Or use a more sophisticated notification system if available
    }
  }

  return (
    <div className="card m-4 bg-base-100 shadow-xl w-full max-w-md ">
      <div className="card-body">
        <h2 className="card-title">{list.title}</h2>
        <span className="max-h-20 overflow-y-auto block">
          {list.description}
        </span>

        <TaskItems
          Tasks={filteredTasks}
          onUpdateTaskClick={onUpdateTaskClick}
        ></TaskItems>
        <button className="btn btn-neutral" onClick={handleAddClicked}>
          Add Task
        </button>
      </div>
      <div className="absolute right-5 top-5">
        <button
          className="btn btn-circle btn-sm mr-3"
          onClick={handleUpdateListClicked}
        >
          <FontAwesomeIcon className="size-4" icon={faPen} />
        </button>
        <button
          className="btn btn-circle btn-sm"
          onClick={handelDeleteListClicked}
        >
          <FontAwesomeIcon className="size-4" icon={faTrash} />
        </button>
      </div>
    </div>
  )
}
