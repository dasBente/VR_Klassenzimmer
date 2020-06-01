import { configureStore } from '@reduxjs/toolkit'
import studentsReducer from '../features/classState/studentsSlice'
import websocketReducer from '../features/websocket/websocketSlice'

export default configureStore({
  reducer: {
    students: studentsReducer,
    websocket: websocketReducer
  },
});
