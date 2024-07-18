import TaskItems from "./TaskItems";
import TaskItemInput from "./TaskItemInput";

import ITask from "@modelsTaskInterface";
import IList from "@modelsListInterface";

import { useSelector } from "react-redux";
import { RootState } from "@storestore";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

export default function TaskList({ list }: { list: IList }) {
  const tasks: ITask[] = useSelector((state: RootState) =>
    state.task.tasks.filter((task) => task.listId === list.listId),
  );

  const [showForm, setShowForm] = useState(false);

  const handleClicked = () => {
    setShowForm(true);
  };

  return (
    <>
      <div
        className={`${showForm ? "pointer-events-none blur-sm" : ""} card m-4 bg-base-100 shadow-xl lg:w-1/3`}
      >
        <div className="card-body">
          <h2 className="card-title">{list.title}</h2>
          <p>{list.description}</p>
          <TaskItems Tasks={tasks}></TaskItems>
          <button className="btn btn-neutral" onClick={handleClicked}>
            Add Task
          </button>
        </div>
        <button className="btn btn-circle btn-sm absolute right-5 top-5">
          <FontAwesomeIcon className="size-4" icon={faTrash} />
        </button>
      </div>
      {showForm && (
        <div className="fixed inset-0 z-50 flex items-center justify-center">
          <TaskItemInput
            onClose={() => setShowForm(false)}
            listId={list.listId ?? ""}
          />
        </div>
      )}
    </>
  );
}
