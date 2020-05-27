import React from 'react'
import PropTypes from 'prop-types'
import { behaviourColors } from './constants'

const BehaviourButton = ({ behaviour, onClick }) => (
  <button
    className={`btn btn-${behaviourColors[behaviour]}`} type='button' key={behaviour}
    onClick={() => onClick(behaviour)}
  >
    {behaviour}
  </button>
)

BehaviourButton.propTypes = {
  behaviour: PropTypes.string.isRequired,
  onClick: PropTypes.func
}

export default BehaviourButton
