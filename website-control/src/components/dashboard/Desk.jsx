import React from 'react'
import PropTypes from 'prop-types'
import StudentState from './StudentState'

const Desk = ({ students }) => (
  <div className='col mb-4'>
    <div className='card'>
      <ul className='list-group list-group-horizontal'>
        {students.map((s, i) => (<StudentState key={i} student={s} />))}
      </ul>
    </div>
  </div>
)

Desk.propTypes = {
  students: PropTypes.arrayOf(PropTypes.object).isRequired
}

export default Desk
