export const goodBehaviours = ['idle', 'writing', 'raiseArm', 'question']

export const badBehaviours = [
  'eatApple', 'drinking', 'letargic_starring', 'play with accesoires', 'starring', 'hitting',
  'throwing', 'chatting', 'throwPaperBall'
]

const NEUTRAL = 'light'
const WARNING = 'warning'
const DANGER = 'danger'
const GOOD = 'success'

export const behaviourColors = {
  idle: NEUTRAL,
  eatApple: WARNING,
  drinking: WARNING,
  letargic_starring: WARNING,
  'play with accesoires': WARNING,
  starring: WARNING,
  hitting: DANGER,
  throwPaperBall: DANGER,
  chatting: DANGER,
  writing: GOOD,
  raiseArm: GOOD, // TODO another category for students requesting for teachers attention?
  question: GOOD
}
