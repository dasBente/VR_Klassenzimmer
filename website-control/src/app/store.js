import { configureStore } from '@reduxjs/toolkit';
import studentsReducer from '../features/classState/studentsSlice';

export default configureStore({
  reducer: {
    students: studentsReducer
  },
});
