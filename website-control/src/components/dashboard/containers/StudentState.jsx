import StudentState from '../StudentState'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { toggleStudent } from 'actions/students'

const mapDispatchToProps = (dispatch, { student }) => ({
  toggle: () => dispatch(toggleStudent(student.id))
})

const StudentStateContainer = connect(undefined, mapDispatchToProps)(StudentState)

StudentStateContainer.propTypes = {
  student: PropTypes.shape({
    id: PropTypes.int
  }).isRequired
}

export default StudentStateContainer
