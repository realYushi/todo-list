import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IList from "@models/ListInterface";
export interface ListState {
  lists: IList[];
}

export const initialState: ListState = {
  lists: [
    {
      listId: "1",
      title: "Grocery List",
      description: "Items needed for the week",
      updatedAt: "2023-10-05",
      tasks: [],
    },
    {
      listId: "2",
      title: "Work Tasks",
      description: "Tasks for the upcoming week",
      createdAt: "2023-10-02",
      updatedAt: "2023-10-06",
      tasks: [],
    },
  ],
};
const listSlice = createSlice({
  name: "list",
  initialState,
  reducers: {
    addList(state, action: PayloadAction<IList>) {
      state.lists.push(action.payload);
    },
    updateList() {},
    deleteList() {},
    readLists() {},
  },
});
export default listSlice.reducer;
export const { addList, updateList, deleteList, readLists } = listSlice.actions;
