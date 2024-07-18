import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IList from "@models/ListInterface";
export interface ListState {
  lists: IList[];
}

const initialState: ListState = {
  // lists: [],
  lists: [
    {
      listId: "1",
      title: "Grocery List",
      description: "Items needed for the week",
      updatedAt: "2023-10-05",
      tasks: [
        {
          taskId: "1",
          title: "Buy milk",
          description: "2% milk",
          dueDate: new Date("2023-10-07"),
          listId: "1",
          status: "Pending",
        },
        {
          taskId: "2",
          title: "Buy eggs",
          description: "A dozen eggs",
          dueDate: new Date("2023-10-07"),
          listId: "1",
          status: "InProgress",
        },
      ],
    },
    {
      listId: "2",
      title: "Work Tasks",
      description: "Tasks for the upcoming week",
      createdAt: "2023-10-02",
      updatedAt: "2023-10-06",
      tasks: [
        {
          taskId: "3",
          title: "Prepare presentation",
          description: "For the team meeting",
          dueDate: new Date("2023-10-10"),
          listId: "2",
          status: "Pending",
        },
        {
          taskId: "4",
          title: "Review code",
          description: "Review the new feature implementation",
          dueDate: new Date("2023-10-09"),
          listId: "2",
          status: "InProgress",
        },
      ],
    },
    // Add more lists as needed
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
