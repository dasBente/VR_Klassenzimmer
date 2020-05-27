import { INIT_STUDENTS } from 'actions/students'

const students = (state = [], action) => {
  switch (action.type) {
    case INIT_STUDENTS:
      return [...Array(15)].map(i => ({ desk: i, name: 'TEMP', seat: 'L', action: 'idle' }))
        .concat([...Array(15)].map(i => ({ desk: i, name: 'TEMP', seat: 'R', action: 'idle' })))
    default:
      return state
  }
}

export default students
