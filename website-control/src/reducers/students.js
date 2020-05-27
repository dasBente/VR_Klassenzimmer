import { INIT_STUDENTS } from 'actions/students'

const range = (i) => [...Array(i).keys()]

const students = (state = [], action) => {
  switch (action.type) {
    case INIT_STUDENTS:
      return range(15).reduce(
        (res, i) => [
          ...res,
          { desk: i, name: 'TEMP', seat: 'L', action: 'idle' },
          { desk: i, name: 'TEMP', seat: 'R', action: 'idle' }
        ],
        []
      )
    default:
      return state
  }
}

export default students
