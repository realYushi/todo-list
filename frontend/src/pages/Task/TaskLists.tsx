import TaskList from "./TaskList";
import { useDispatch, useSelector } from "react-redux";
import { RootState, AppDispatch } from "@store/store";
import { addList } from "@storetask/listSlice";

export default function TaskLists() {
  const lists = useSelector((state: RootState) => state.list.lists);
  const dispach = useDispatch<AppDispatch>();
  return (
    <>
      <div className="justify-center gap-12 lg:flex">
        {lists.map((list) => (
          <TaskList key={list.listId} list={list} tasks={list.tasks} />
        ))}
      </div>
      <div className="m-4 flex justify-center">
        <button
          className="btn btn-neutral w-1/2 lg:w-1/4"
          onClick={() => dispach(addList())}
        >
          New List
        </button>
      </div>
    </>
  );
}
