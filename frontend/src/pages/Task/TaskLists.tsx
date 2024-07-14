import { Task } from "@pages/Task/TaskItem";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
export function Lists() {
  return (
    <div className="justify-center gap-12 lg:flex">
      <List />
      <List />
    </div>
  );
}
export function List() {
  const taskTitle = ["Task 1", "Task 2", "Task 3"];

  return (
    <>
      <div className="card m-4 bg-base-100 shadow-xl lg:w-1/3">
        <div className="card-body">
          <h2 className="card-title">Inbox</h2>
          <p>this is default list</p>
          <div className="card-actions grid grid-cols-1">
            {taskTitle.map((taskTitle, index) => (
              <Task key={index} taskName={taskTitle} />
            ))}
          </div>
          <button className="btn btn-neutral">Add Task</button>
        </div>
        <button className="btn btn-circle btn-sm absolute right-5 top-5">
          <FontAwesomeIcon className="size-4" icon={faTrash} />
        </button>
      </div>
    </>
  );
}
