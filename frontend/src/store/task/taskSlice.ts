import { createSlice } from "@reduxjs/toolkit";
interface Task {
  taskId?: string;
  title: string;
  description: string;
  dueDate?: Date;
  listId: string;
  status: "Pending" | "InProgress" | "Completed";
  userId: string;
  rowVersion?: string;
}

export interface TaskState {
  tasks: Task[];
}

const initialState: TaskState = {
  tasks: [],
};
const taskSlice = createSlice({
  name: "task",
  initialState,
  reducers: {},
});
export default taskSlice.reducer;
