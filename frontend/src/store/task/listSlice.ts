import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IList from "@models/ListInterface";
export interface ListState {
  lists: IList[];
}

export const initialState: ListState = {
  lists: [],
};
const listSlice = createSlice({
  name: "list",
  initialState,
  reducers: {
    addList(state, action: PayloadAction<IList>) {
      state.lists.push(action.payload);
    },
    updateList(state, action: PayloadAction<IList>) {
      const listIndex = state.lists.findIndex(
        (list) => list.listId === action.payload.listId,
      );
      state.lists[listIndex] = action.payload;
    },
    deleteList(state, action: PayloadAction<string>) {
      state.lists = state.lists.filter(
        (list) => list.listId !== action.payload,
      );
    },
  },
});
export default listSlice.reducer;
export const { addList, updateList, deleteList } = listSlice.actions;
