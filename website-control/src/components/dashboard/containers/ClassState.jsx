import ClassState from '../ClassState'
import { connect } from 'react-redux'
import { initStudents } from 'actions/students'

const mapStateToProps = ({ students }) => {
  const res = []

  students.forEach(s => {
    if (!res[s.desk]) res[s.desk] = []
    res[s.desk].append(s)
  })

  return { desks: res.filter(r => r) }
}

const mapDispatchToProps = {
  init: initStudents
}

const ClassStateContainer = connect(mapStateToProps, mapDispatchToProps)(ClassState)

export default ClassStateContainer
