import TaskList from "./TaskList";
import { useSelector } from "react-redux";
import { RootState } from "@store/store";
import TaskListInput from "./TaskListInput";
import React, { useState } from "react";

export default function TaskLists() {
  const lists = useSelector((state: RootState) => state.list.lists);
  const [showForm, setShowForm] = useState(false);

  const handleClicked = () => {
    setShowForm(true);
  };

  return (
    <>
      <div
        className={`justify-center gap-12 lg:flex ${showForm ? "pointer-events-none blur-sm" : ""}`}
      >
        {lists.map((list) => (
          <TaskList key={list.listId} list={list} tasks={list.tasks} />
        ))}
      </div>
      <div className="m-4 flex justify-center">
        <button
          className="btn btn-neutral w-1/2 lg:w-1/4"
          onClick={handleClicked}
        >
          New List
        </button>
      </div>
      {showForm && (
        <div className="fixed inset-0 z-50 flex items-center justify-center">
          <TaskListInput onClose={() => setShowForm(false)} />
        </div>
      )}
    </>
  );
}
