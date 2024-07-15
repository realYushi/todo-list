import { createSlice } from "@reduxjs/toolkit";
import IList from "@models/ListInterface";
export interface ListState {
  lists: IList[];
}

const initialState: ListState = {
  lists: [],
};
const listSlice = createSlice({
  name: "list",
  initialState,
  reducers: {
    addList() {},
    updateList() {},
    deleteList() {},
    readLists() {},
  },
});
export default listSlice.reducer;
export const { addList, updateList, deleteList, readLists } = listSlice.actions;
