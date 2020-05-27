import React from 'react'
import PropTypes from 'prop-types'
import { behaviourColors } from './constants'

const StudentState = ({ student: { id, name, behaviour, selected }, toggle }) => (
  <div className='mb-2'>
    <ul className='card list-group'>
      <li className='list-group-item'>
        <button
          className={`font-weight-bolder btn btn-${!selected ? 'outline-' : ''}primary`}
          type='button'
          onClick={() => toggle(id)}
        >
          {name}
        </button>
      </li>
      <li className={`list-group-item list-group-item-${behaviourColors[behaviour]}`}>
        <span>{behaviour}</span>
      </li>
    </ul>
  </div>
)

StudentState.propTypes = {
  student: PropTypes.shape({
    name: PropTypes.string,
    id: PropTypes.int,
    behaviour: PropTypes.string,
    selected: PropTypes.bool
  }).isRequired,
  toggle: PropTypes.func
}

export default StudentState
