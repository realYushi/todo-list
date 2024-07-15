import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPen } from "@fortawesome/free-solid-svg-icons";
import ITask from "@models/TaskInterface";

interface TaskProps {
  task: ITask;
}
export default function TaskItem({ task }: TaskProps) {
  return (
    <div className="form-control">
      <label className="label relative m-4 flex items-center rounded-md p-4 shadow-md">
        <input type="checkbox" className="checkbox checkbox-md mr-4 size-8" />
        <div className="flex-grow">
          <h3 className="text-xl">{task.title}</h3>
          <p className="text-sm">{task.description}</p>
          <p className="text-sm">{task.dueDate.toString()}</p>
        </div>
        <div className="flex flex-col space-y-2">
          <button className="btn btn-circle btn-sm">
            <FontAwesomeIcon className="size-4" icon={faTrash} />
          </button>
          <button className="btn btn-circle btn-sm">
            <FontAwesomeIcon className="size-4" icon={faPen} />
          </button>
        </div>
      </label>
    </div>
  );
}
