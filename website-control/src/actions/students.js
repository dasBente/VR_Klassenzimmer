export const INIT_STUDENTS = 'students/INIT_STUDENTS'
export const initStudents = () => ({ type: INIT_STUDENTS })

export const TOGGLE_STUDENT = 'students/TOGGLE_STUDENT'
export const toggleStudent = id => ({ type: TOGGLE_STUDENT, payload: id })

export const SELECT_ALL = 'students/SELECT_ALL'
export const selectAll = to => ({ type: SELECT_ALL, payload: to })

export const TRIGGER_BEHAVIOUR = 'students/TRIGGER_BEHAVIOUR'
export const triggerBehaviour = behaviour => ({
  type: TRIGGER_BEHAVIOUR, payload: behaviour
})
