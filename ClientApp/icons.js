import { library } from '@fortawesome/fontawesome-svg-core'
// Official documentation available at: https://github.com/FortAwesome/vue-fontawesome
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

import { faBell,faCommentDots,faUtensils,faNewspaper,faGlobe,faGlassCheers,faHome,faPhoneSquare,faShoppingBasket,faClock,faTags,faPen,faTrash } from '@fortawesome/free-solid-svg-icons'

// If not present, it won't be visible within the application. Considering that you
// don't want all the icons for no reason. This is a good way to avoid importing too many
// unnecessary things.
library.add(
  faBell,
  faCommentDots,
  faUtensils,
  faNewspaper,
  faGlobe,
  faGlassCheers,
  faHome,
  faPhoneSquare,
  faShoppingBasket,
  faClock,
  faTags,
  faPen,
  faTrash
)

export {
  FontAwesomeIcon
}
