import { INIT_STUDENTS } from 'actions/students'

const students = (state = [], action) => {
  switch (action.type) {
    case INIT_STUDENTS: {
      const s = []

      for (let desk = 1; desk <= 15; desk++) {
        s.append({ desk, seat: 'L', name: 'TEMP', action: 'idle' })
        s.append({ desk, seat: 'R', name: 'TEMP', action: 'idle' })
      }

      return s
    }
    default:
      return state
  }
}

export default students
