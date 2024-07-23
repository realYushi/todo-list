import TaskList from "./TaskList"
import TaskListInput from "./TaskListInput"
import TaskItemInput from "./TaskItemInput"
import { useState } from "react"
import ITask from "@models/TaskInterface"
import IList from "@models/ListInterface"
import { useGetListsQuery } from "@service/listEndpoint"

/**
 * Component for rendering the task lists.
 */
export default function TaskLists() {
  const { data: lists } = useGetListsQuery()
  const [updateTask, setUpdateTask] = useState<ITask | null>(null)
  const [updateList, setUpdateList] = useState<IList | null>(null)
  const [showListForm, setShowListForm] = useState(false)
  const [showTaskForm, setShowTaskForm] = useState(false)
  const [activeListId, setActiveListId] = useState<string>("")

  /**
   * Handles the click event for adding a new list.
   */
  const handleAddListClick = () => {
    setShowListForm(true)
  }

  /**
   * Handles the click event for editing a list.
   * @param list - The list to be updated.
   */
  const handleListInputClick = (list: IList) => {
    setShowListForm(true)
    setUpdateList(list)
  }

  /**
   * Handles the click event for adding a new task.
   * @param listId - The ID of the list to which the task will be added.
   */
  const handleAddTaskClick = (listId: string) => {
    setShowTaskForm(true)
    setActiveListId(listId)
  }

  /**
   * Handles the click event for editing a task.
   * @param task - The task to be updated.
   */
  const handleTaskInputClick = (task: ITask) => {
    setShowTaskForm(true)
    setUpdateTask(task)
  }

  const isBlurred = showListForm || showTaskForm

  return (
    <>
      <div
        className={`grid grid-cols-1 justify-items-center gap-14 md:grid-cols-2 lg:grid-cols-3 ${
          isBlurred ? "pointer-events-none blur-sm" : ""
        } ${lists && lists.length === 1 ? "md:grid-cols-1 lg:grid-cols-1" : ""}`}
      >
        {lists &&
          lists.map((list: IList) => (
            <TaskList
              key={list.listId}
              list={list}
              onAddTaskClick={handleAddTaskClick}
              onUpdateTaskClick={handleTaskInputClick}
              onUpdateListClick={handleListInputClick}
            />
          ))}
      </div>
      <div
        className={`${
          isBlurred ? "pointer-events-none blur-sm" : ""
        } m-4 flex justify-center`}
      >
        <button
          className="btn btn-neutral w-1/2 lg:w-1/4"
          onClick={handleAddListClick}
        >
          New List
        </button>
      </div>
      {showListForm && (
        <div className="fixed inset-0 z-50 flex items-center justify-center">
          <TaskListInput
            onListClose={() => {
              setShowListForm(false)
              setUpdateList(null)
            }}
            listToUpdate={updateList}
          />
        </div>
      )}
      {showTaskForm && (
        <div className="fixed inset-0 z-50 flex items-center justify-center">
          <TaskItemInput
            taskToUpdate={updateTask}
            onTaskClose={() => {
              setShowTaskForm(false)
              setUpdateTask(null)
            }}
            listId={activeListId}
          />
        </div>
      )}
    </>
  )
}
