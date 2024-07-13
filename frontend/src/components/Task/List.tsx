export function List() {
  const taskTitle = ["Task 1", "Task 2", "Task 3"];

  return (
    <>
      <div className="card m-4 bg-base-100 shadow-xl">
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
        <button className="btn btn-circle btn-ghost btn-sm absolute right-1 top-1">
          X
        </button>
      </div>
    </>
  );
}

function Task({ taskName }: { taskName: string }) {
  return (
    <div className="form-control col-span-1">
      <label className="label relative m-4 grid cursor-pointer grid-cols-6 items-center rounded-md bg-gray-100 shadow-md">
        <input
          type="checkbox"
          className="checkbox-success checkbox col-span-1 col-start-1 size-8"
        />
        <div className="col-span-4">
          <h3 className="label-text text-xl">{taskName}</h3>
          <p className="label-text">Due</p>
          <p className="label-text">task detail</p>
          <button className="btn btn-circle btn-ghost btn-sm absolute right-1 top-1">
            X
          </button>
        </div>
      </label>
    </div>
  );
}
