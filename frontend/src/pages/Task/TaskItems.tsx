import ITask from "@modelsTaskInterface";
import TaskItem from "@pages/Task/TaskItem";
export default function TaskItems({ Tasks }: { Tasks: ITask[] }) {
  return (
    <div className="card-actions grid grid-cols-1">
      {Tasks.map((task) => (
        <TaskItem key={task.taskId} task={task} />
      ))}
    </div>
  );
}
