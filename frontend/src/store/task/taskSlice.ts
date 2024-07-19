import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import ITask from "@models/TaskInterface";

export interface TaskState {
  tasks: ITask[];
}

export const initialState: TaskState = {
  tasks: [],
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
