import React from 'react'
import PropTypes from 'prop-types'
import StudentState from './StudentState'

const Desk = ({ students }) => (
  <div className='col'>
    {students.map((s, i) => (<StudentState key={i} student={s} />))}
  </div>
)

Desk.propTypes = {
  students: PropTypes.arrayOf(PropTypes.object).isRequired
}

export default Desk
