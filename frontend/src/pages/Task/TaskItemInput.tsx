import ITask from "@modelsTaskInterface";
import { RootState } from "@storestore";
import { addTask } from "@storetask/taskSlice";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

interface TaskItemInputProps {
  onClose: () => void;
  listId: string;
}
export default function TaskItemInput({ onClose, listId }: TaskItemInputProps) {
  const tasks = useSelector((state: RootState) => state.task.tasks);
  const dispatch = useDispatch();

  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [dueDate, setDueDate] = useState<string>("");
  const handleAddTask = () => {
    const newTask: ITask = {
      taskId: tasks.length.toString(),
      title: title,
      description: description,
      dueDate: new Date(dueDate).toString(),
      listId: listId,
      status: "Pending",
    };
    dispatch(addTask(newTask));
    onClose();
  };

  return (
    <div className="absolute rounded-lg bg-neutral-50">
      <div className="label">
        <span className="label-text">Task Name</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        className="input input-bordered input-secondary w-full"
      />
      <div className="label">
        <span className="label-text">Task Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        className="textarea textarea-bordered w-full"
      ></textarea>
      <div className="label">
        <span className="label-text">Due Date</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <div className="flex items-center">
        <input
          type="date"
          value={dueDate}
          onChange={(e) => setDueDate(e.target.value)}
          className="input input-bordered w-full"
        />
      </div>
      <div className="mt-5">
        <button className="btn btn-primary w-1/2" onClick={handleAddTask}>
          Confirm
        </button>
        <button className="btn btn-warning w-1/2" onClick={() => onClose()}>
          Close
        </button>
      </div>
    </div>
  );
}
