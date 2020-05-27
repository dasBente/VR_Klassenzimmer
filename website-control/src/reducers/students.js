import { INIT_STUDENTS, TOGGLE_STUDENT, SELECT_ALL, TRIGGER_BEHAVIOUR } from 'actions/students'

const range = (i) => [...Array(i).keys()]

const updateMatching = (arr, query, updateFn) => arr.map(v => query(v) ? updateFn(v) : v)

const students = (state = [], { type, payload }) => {
  switch (type) {
    case INIT_STUDENTS:
      return range(30).map(i => ({ id: i, name: 'TEMP', behaviour: 'idle', selected: false }))
    case TOGGLE_STUDENT:
      return updateMatching(state, s => s.id === payload, s => ({ ...s, selected: !s.selected }))
    case SELECT_ALL:
      return state.map(s => ({ ...s, selected: payload }))
    case TRIGGER_BEHAVIOUR:
      return state.map(
        s => s.selected ? ({ ...s, selected: false, behaviour: payload }) : s
      )
    default:
      return state
  }
}

export default students
