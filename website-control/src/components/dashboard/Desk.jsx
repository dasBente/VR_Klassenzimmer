import React from 'react'
import PropTypes from 'prop-types'

const Desk = ({ students }) => (
  <div />
)

Desk.propTypes = {
  students: PropTypes.arrayOf(PropTypes.object).isRequired
}

export default Desk
