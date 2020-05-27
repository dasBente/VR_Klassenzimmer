import ClassState from '../ClassState'
import { connect } from 'react-redux'
import { initStudents, selectAll } from 'actions/students'

const mapStateToProps = ({ students }) => ({ students })

const mapDispatchToProps = {
  init: initStudents,
  selectAll: b => selectAll(b)
}

const ClassStateContainer = connect(mapStateToProps, mapDispatchToProps)(ClassState)

export default ClassStateContainer
