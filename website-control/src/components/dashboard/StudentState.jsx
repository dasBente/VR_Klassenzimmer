import React from 'react'
import PropTypes from 'prop-types'

const StudentState = ({ student: { name, action } }) => (
  <div>
    <span className='font-weight-bolder'>{name}</span>
  </div>
)

StudentState.propTypes = {
  student: PropTypes.shape({ name: PropTypes.string, action: PropTypes.string }).isRequired
}

export default StudentState
