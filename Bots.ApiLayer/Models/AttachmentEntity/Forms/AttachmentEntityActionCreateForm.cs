using Bots.ApiLayer.Models.AttachmentEntity.Views;

namespace Bots.ApiLayer.Models.AttachmentEntity.Forms
{
    public class AttachmentEntityActionCreateForm : AttachmentEntityActionBaseView
    {
        public AttachmentEntityActionCreateForm()
            :base()
        {

        }

        public AttachmentEntityActionCreateForm(AttachmentEntityActionDestinationType destinationTypeVal)
            :base(destinationTypeVal)
        {

        }

		//private object _data;


        // IAttachmentEntityActionView - все возможные будущие кнопки/чекбоксы и т.д.... на данный момент нам интересно только AttachmentEntityActionButtonView
	    /// <summary>
	    /// Данные действия
	    /// </summary>
	    public AttachmentEntityActionButtonView data { get; set; }
	    //{
		   // get { return _data as IAttachmentEntityActionView; }
		   // set
		   // {
			  //  _data = value;
		   // }
	    //}
    }
}
