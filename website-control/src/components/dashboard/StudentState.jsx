import React from 'react'
import PropTypes from 'prop-types'

const StudentState = ({ student: { name, action }, active }) => (
  <li className='list-group-item'>
    <button
      className={`font-weight-bolder btn btn-${!active ? 'outline-' : ''}primary`} type='button'
    >
      {name}
    </button>
    <span>{action}</span>
  </li>
)

StudentState.propTypes = {
  student: PropTypes.shape({ name: PropTypes.string, action: PropTypes.string }).isRequired,
  active: PropTypes.bool
}

StudentState.defaultProps = {
  active: false
}

export default StudentState
