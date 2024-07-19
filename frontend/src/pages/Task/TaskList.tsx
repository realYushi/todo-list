import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "@store/store";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPen } from "@fortawesome/free-solid-svg-icons";
import TaskItems from "./TaskItems";
import ITask from "@models/TaskInterface";
import IList from "@models/ListInterface";

interface TaskListProps {
  list: IList;
  onUpdateListClick: (list: IList) => void;
  onUpdateTaskClick: (task: ITask) => void;
  onAddTaskClick: (listId: string) => void;
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
  const tasks: ITask[] = useSelector((state: RootState) =>
    state.task.tasks.filter((task) => task.listId === list.listId),
  );

  /**
   * Handles the click event when the "Add Task" button is clicked.
   */
  const handleAddClicked = () => {
    onAddTaskClick(list.listId ?? "");
  };
  const handleUpdateListClicked = () => {
    onUpdateListClick(list);
  };
  return (
    <div className="card m-4 bg-base-100 shadow-xl lg:w-1/3">
      <div className="card-body">
        <h2 className="card-title">{list.title}</h2>
        <p>{list.description}</p>
        <TaskItems
          Tasks={tasks}
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
        <button className="btn btn-circle btn-sm">
          <FontAwesomeIcon className="size-4" icon={faTrash} />
        </button>
      </div>
    </div>
  );
}
