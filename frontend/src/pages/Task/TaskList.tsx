import TaskItems from "./TaskItems";
import IList from "@modelsListInterface";
import ITask from "@modelsTaskInterface";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import { faTrash } from "@fortawesome/free-solid-svg-icons";

interface ListProps {
  tasks: ITask[];
  list: IList;
}
export default function TaskList({ list, tasks }: ListProps) {
  return (
    <>
      <div className="card m-4 bg-base-100 shadow-xl lg:w-1/3">
        <div className="card-body">
          <h2 className="card-title">{list.title}</h2>
          <p>{list.description}</p>
          <TaskItems Tasks={tasks}></TaskItems>
          <button className="btn btn-neutral">Add Task</button>
        </div>
        <button className="btn btn-circle btn-sm absolute right-5 top-5">
          <FontAwesomeIcon className="size-4" icon={faTrash} />
        </button>
      </div>
    </>
  );
}
