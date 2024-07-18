import { RootState } from "@store/store";
import { useSelector, useDispatch } from "react-redux";
import IList from "@modelsListInterface";
import { addList } from "@store/task/listSlice";
import { useState } from "react";

export default function TaskListInput({ onClose }: { onClose: any }) {
  const lists = useSelector((state: RootState) => state.list.lists);
  const dispatch = useDispatch();

  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");

  const handleAddList = () => {
    let newList: IList = {
      listId: Date.now().toString(),
      title: title,
      description: description,
      tasks: [],
    };
    dispatch(addList(newList));
    onClose();
  };

  return (
    <form className="absolute rounded-lg bg-neutral-50">
      <div className="label">
        <span className="label-text">List Description</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        value={title}
        className="input input-bordered input-primary w-full"
        onChange={(e) => setTitle(e.target.value)}
      />
      <div className="label">
        <span className="label-text">List Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea
        value={description}
        className="textarea textarea-bordered w-full"
        onChange={(e) => setDescription(e.target.value)}
      ></textarea>

      <div className="mt-5">
        <button className="btn btn-neutral w-1/2" onClick={handleAddList}>
          Confirm
        </button>
        <button className="btn btn-active w-1/2" onClick={() => onClose()}>
          Close
        </button>
      </div>
    </form>
  );
}
