import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPen } from "@fortawesome/free-solid-svg-icons";
import ITask from "@models/TaskInterface";

interface TaskProps {
  task: ITask;
  onUpdateTaskClick: (task: ITask) => void;
}

/**
 * Component representing a single task item.
 * @param {TaskProps} props - The props for the TaskItem component.
 * @param {ITask} props.task - The task object.
 * @param {(task: ITask) => void} props.onUpdateTaskClick - The function to call when the task is updated.
 * @returns {JSX.Element} The TaskItem component.
 */
export default function TaskItem({
  task,
  onUpdateTaskClick,
}: TaskProps): JSX.Element {
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
          <button
            className="btn btn-circle btn-sm"
            onClick={() => onUpdateTaskClick(task)}
          >
            <FontAwesomeIcon className="size-4" icon={faPen} />
          </button>
        </div>
      </label>
    </div>
  );
}
