import Desk from '../Desk'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'

const mapStateToProps = ({ students }, { desk }) => ({
  students: students.filter(s => s.desk === desk)
})

const DeskContainer = connect(mapStateToProps)(Desk)

DeskContainer.propTypes = {
  desk: PropTypes.int.isRequired
}

export default DeskContainer
