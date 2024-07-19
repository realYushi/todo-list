import ITask from "@models/TaskInterface";
import TaskItem from "@pages/Task/TaskItem";

/**
 * Props for the TaskItems component.
 */
interface TaskItemsProps {
  Tasks: ITask[]; // An array of tasks
  onUpdateTaskClick: (task: ITask) => void; // Callback function for task update
}

/**
 * Renders a list of task items.
 * @param Tasks - An array of tasks
 * @param onTaskUpdate - Callback function for task update
 * @returns JSX element representing the list of task items
 */
export default function TaskItems({
  Tasks,
  onUpdateTaskClick,
}: TaskItemsProps) {
  return (
    <div className="grid-cols-1ds card-actions grid">
      {Tasks.map((task) => (
        <TaskItem
          key={task.taskId}
          task={task}
          onUpdateTaskClick={onUpdateTaskClick}
        />
      ))}
    </div>
  );
}
