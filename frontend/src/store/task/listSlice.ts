import { createSlice } from "@reduxjs/toolkit";
interface List {
  listId: string | null;
  title: string;
  description: string;
  createdAt: string;
  updatedAt: string | null;
}
interface ListState {
  tasks: List[];
}

const initialState: ListState = {
  tasks: [],
};
const taskSlice = createSlice({
  name: "task",
  initialState,
  reducers: {
    addList() {},
    updateList() {},
    deleteList() {},
    readLists() {},
  },
});
export default taskSlice.reducer;
