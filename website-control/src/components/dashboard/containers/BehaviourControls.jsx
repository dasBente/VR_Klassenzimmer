import BehaviourControls from '../BehaviourControls'
import { connect } from 'react-redux'
import { triggerBehaviour } from 'actions/students'

const mapDispatchToProps = {
  triggerBehaviour: b => triggerBehaviour(b)
}

export default connect(undefined, mapDispatchToProps)(BehaviourControls)
