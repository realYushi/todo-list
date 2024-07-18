import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import ITask from "@models/TaskInterface";

export interface TaskState {
  tasks: ITask[];
}

export const initialState: TaskState = {
  tasks: [
    {
      taskId: "1",
      title: "Buy milk",
      description: "2% milk",
      dueDate: new Date("2023-10-07").toString(),
      listId: "1",
      status: "Pending",
    },
    {
      taskId: "2",
      title: "Buy eggs",
      description: "A dozen eggs",
      dueDate: new Date("2023-10-07").toString(),
      listId: "1",
      status: "InProgress",
    },
    {
      taskId: "3",
      title: "Prepare presentation",
      description: "For the team meeting",
      dueDate: new Date("2023-10-10").toString(),
      listId: "2",
      status: "Pending",
    },
    {
      taskId: "4",
      title: "Review code",
      description: "Review the new feature implementation",
      dueDate: new Date("2023-10-09").toString(),
      listId: "2",
      status: "InProgress",
    },
  ],
};

const taskSlice = createSlice({
  name: "task",
  initialState,
  reducers: {
    addTask(state, action: PayloadAction<ITask>) {
      state.tasks.push(action.payload);
    },
    updateTask(state, action: PayloadAction<ITask>) {
      const taskIndex = state.tasks.findIndex(
        (task) => task.taskId === action.payload.taskId,
      );
      if (taskIndex !== -1) {
        state.tasks[taskIndex] = action.payload;
      }
    },
    deleteTask(state, action: PayloadAction<string>) {
      state.tasks = state.tasks.filter(
        (task) => task.taskId !== action.payload,
      );
    },
  },
});

export default taskSlice.reducer;
export const { addTask, updateTask, deleteTask } = taskSlice.actions;
