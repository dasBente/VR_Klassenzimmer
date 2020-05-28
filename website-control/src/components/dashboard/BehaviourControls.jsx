import React from 'react'
import PropTypes from 'prop-types'
import { goodBehaviours, badBehaviours } from 'constants/behaviour'
import BehaviourButton from './BehaviourButton'

const BehaviourControls = ({ triggerBehaviour }) => (
  <div className='row'>
    <div className='col border-right'>
      <h3>Good behaviours</h3>
      <div className='btn-group'>
        {goodBehaviours.map(
          b => <BehaviourButton key={b} behaviour={b} onClick={triggerBehaviour} />)}
      </div>
    </div>
    <div className='col border-left'>
      <h3>Bad behaviours</h3>
      <div className='btn-group'>
        {badBehaviours.map(b =>
          <BehaviourButton key={b} behaviour={b} onClick={triggerBehaviour} />)}
      </div>
    </div>
  </div>
)

BehaviourControls.propTypes = {
  triggerBehaviour: PropTypes.func
}

export default BehaviourControls
