export function List() {
    const taskTitle = ["Task 1", "Task 2", "Task 3"];

    return (
        <>
            <div className="card bg-base-100 shadow-xl m-4">
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
            </div>
        </>
    );
}

function Task({ taskName }: { taskName: string }) {
    return (
        <div className="form-control col-span-1 ">
            <label className="cursor-pointer label grid grid-cols-4 items-center bg-gray-100">
                <input
                    type="checkbox"
                    className="checkbox checkbox-success col-span-1 col-start-2"
                />
                <span className="label-text col-span-2">{taskName}</span>
            </label>
        </div>
    );
}
