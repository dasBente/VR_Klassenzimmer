import { createSlice } from '@reduxjs/toolkit';

export const studentsSlice = createSlice({
  name: 'students',
  initialState: [],
  reducers: {
    init: (state, action) => {
      state = action.payload
    },
    toggle: (state, action) => {
      state = state.map(
        s => action.payload === s.id ? { ...s, selected: !s.selected } : s
      )
    },
    selectAll: (state, action) => {
      state = state.map(s => ({ ...s, selected: action.payload }))
    },
    triggerBehaviour: (state, action) => {
      state = state.map(
        s => s.selected ? { ...s, behaviour: action.payload, selected: false } : s
      )
    },
    syncBehaviour: (state, action) => {
      state = state.map(
        s => s.id === action.payload.id ? { ...s, behaviour: action.payload.behaviour } : s
      )
    }
  }
})

export const { init, toggle, selectAll, triggerBehaviour, syncBehaviour } = studentsSlice.actions;

export const triggerBehaviourAsync = behaviour => dispatch => {
  // TODO: Use websocket for this
  //const students = getState().students.filter(s => s.selected)

  dispatch(triggerBehaviour(behaviour))
}

export default studentsSlice.reducer;
