import TaskList from "./TaskList"
import TaskListInput from "./TaskListInput"
import TaskItemInput from "./TaskItemInput"
import { useState, useEffect } from "react"
import ITask from "@models/TaskInterface"
import IList from "@models/ListInterface"
import { useAddListMutation, useGetListsQuery } from "@service/listEndpoint"

export default function TaskLists() {
  const { data: lists, isLoading, isError, error } = useGetListsQuery()
  const [updateTask, setUpdateTask] = useState<ITask | null>(null)
  const [updateList, setUpdateList] = useState<IList | null>(null)
  const [showListForm, setShowListForm] = useState(false)
  const [showTaskForm, setShowTaskForm] = useState(false)
  const [activeListId, setActiveListId] = useState<string | null>(null)

  const handleAddListClick = () => {
    setShowListForm(true)
  }
  const handleListInputClick = (list: IList) => {
    setShowListForm(true)
    setUpdateList(list)
  }

  const handleAddTaskClick = (listId: string) => {
    setShowTaskForm(true)
    setActiveListId(listId)
  }

  const handleTaskInputClick = (task: ITask) => {
    setShowTaskForm(true)
    setUpdateTask(task)
  }

  const isBlurred = showListForm || showTaskForm

  return (
    <>
      <div
        className={`justify-center lg:grid gap-14 grid-cols-3 ${isBlurred ? "pointer-events-none blur-sm" : ""}`}
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
      <div className="m-4 flex justify-center">
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
      {showTaskForm && activeListId && (
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
