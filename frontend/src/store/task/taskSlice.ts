import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import ITask from "@models/TaskInterface";
export interface TaskState {
  tasks: ITask[];
}

const initialState: TaskState = {
  tasks: [],
};
const listSlice = createSlice({
  name: "task",
  initialState,
  reducers: {
    addTask(state, action: PayloadAction<ITask>) {
      state.tasks.push(action.payload);
    },
    updateTask(state, action: PayloadAction<ITask>) {
      state.tasks = state.tasks.map((task) =>
        task.taskId === action.payload.taskId ? action.payload : task,
      );
    },
    deleteTask(state, action: PayloadAction<string>) {
      state.tasks = state.tasks.filter(
        (task) => task.taskId !== action.payload,
      );
    },
  },
});
export default listSlice.reducer;
export const { addTask, updateTask, deleteTask } = listSlice.actions;
