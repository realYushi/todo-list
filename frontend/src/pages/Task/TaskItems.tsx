import ITask from "@modelsTaskInterface";
import TaskItem from "@pages/Task/TaskItem";

export default function TaskItems({ Tasks }: { Tasks: ITask[] }) {
  return (
    <>
      <div className="grid-cols-1ds card-actions grid">
        {Tasks.map((task) => (
          <TaskItem key={task.taskId} task={task} />
        ))}
      </div>
    </>
  );
}
